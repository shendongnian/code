        public static class TunnelierCustom
        {
            public static PropertyWithComponent Digg(IList<string> trail, object o)
            {
                var type = o.GetType();
                if (trail.Count == 1)
                {
                    return new PropertyWithComponent { Component = o, Property = type.GetProperty(trail[0]) };
                }
                var prop = type.GetProperty(trail[0]);
                var val = prop.GetValue(o);
                if (val == null)
                {
                    if (prop.PropertyType.IsInterface)
                    {
                        if (MapperActivations.InterfaceActivations.ContainsKey(prop.PropertyType))
                        {
                            val = Activator.CreateInstance(MapperActivations.InterfaceActivations[prop.PropertyType]);
                        }
                        else
                        {
                            throw new Exception("Unable to create instance of: " + prop.PropertyType.Name + ". Are you missing InterfaceActivations bidning? Please add it using MapperActivations.AddInterfaceActivation<Interface, Class>() statement");
                        }
                    }
                    else
                    {
                        val = Activator.CreateInstance(prop.PropertyType);
                    }
                    prop.SetValue(o, val);
                }
                trail.RemoveAt(0);
                return Digg(trail, val);
            }
            public static PropertyWithComponent GetValue(IList<string> trail, object o, int level = 0)
            {
                var type = o.GetType();
                if (trail.Count == 1)
                {
                    return new PropertyWithComponent { Component = o, Property = type.GetProperty(trail[0]), Level = level };
                }
                var prop = type.GetProperty(trail[0]);
                var val = prop.GetValue(o);
                if (val == null) return null;
                trail.RemoveAt(0);
                return GetValue(trail, val, level + 1);
            }
        }
        /// <summary>
        /// performs flattening and unflattening
        /// first version of this class was made by Vadim Plamadeala ☺
        /// </summary>
        public static class UberFlatterCustom
        {
            public static IEnumerable<PropertyWithComponent> Unflat(string flatPropertyName, object target, Func<string, PropertyInfo, bool> match, StringComparison comparison)
            {
                var trails = TrailFinder.GetTrails(flatPropertyName, target.GetType().GetProps(), match, comparison, false).Where(o => o != null);
                return trails.Select(trail => TunnelierCustom.Digg(trail, target));
            }
            public static IEnumerable<PropertyWithComponent> Unflat(string flatPropertyName, object target, Func<string, PropertyInfo, bool> match)
            {
                return Unflat(flatPropertyName, target, match, StringComparison.Ordinal);
            }
            public static IEnumerable<PropertyWithComponent> Unflat(string flatPropertyName, object target)
            {
                return Unflat(flatPropertyName, target, (upn, pi) => upn == pi.Name);
            }
            public static IEnumerable<PropertyWithComponent> Flat(string flatPropertyName, object source, Func<string, PropertyInfo, bool> match)
            {
                return Flat(flatPropertyName, source, match, StringComparison.Ordinal);
            }
            public static IEnumerable<PropertyWithComponent> Flat(string flatPropertyName, object source, Func<string, PropertyInfo, bool> match, StringComparison comparison)
            {
                var trails = TrailFinder.GetTrails(flatPropertyName, source.GetType().GetProps(), match, comparison).Where(o => o != null);
                return trails.Select(trail => TunnelierCustom.GetValue(trail, source));
            }
            public static IEnumerable<PropertyWithComponent> Flat(string flatPropertyName, object source)
            {
                return Flat(flatPropertyName, source, (up, pi) => up == pi.Name);
            }
        }
        public class UnflatLoopCustomInjection : ValueInjection
        {
            protected override void Inject(object source, object target)
            {
                var sourceProps = source.GetType().GetProps();
                foreach (var sp in sourceProps)
                {
                    Execute(sp, source, target);
                }
            }
            protected virtual bool Match(string upn, PropertyInfo prop, PropertyInfo sourceProp)
            {
                return prop.PropertyType == sourceProp.PropertyType && upn == prop.Name;
            }
            protected virtual void SetValue(object source, object target, PropertyInfo sp, PropertyInfo tp)
            {
                tp.SetValue(target, sp.GetValue(source));
            }
            protected virtual void Execute(PropertyInfo sp, object source, object target)
            {
                if (sp.CanRead)
                {
                    var endpoints = UberFlatterCustom.Unflat(sp.Name, target, (upn, prop) => Match(upn, prop, sp)).ToArray();
                    foreach (var endpoint in endpoints)
                    {
                        SetValue(source, endpoint.Component, sp, endpoint.Property);
                    }
                }
            }
        }
