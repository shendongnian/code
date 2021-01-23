        using System;
        using System.Collections.Generic;
        using System.Dynamic;
        using System.Linq;
        using System.Linq.Expressions;
        using System.Reflection;
        using System.Runtime.CompilerServices;
        using System.Text;
        using System.Threading.Tasks;
        using Microsoft.CSharp.RuntimeBinder;
        using Binder = Microsoft.CSharp.RuntimeBinder.Binder;
        namespace ConsoleApplication2
        {
            class Program
            {
                class Room
                {
                    public string Value1 { get; set; }
                    public string Value2 { get; set; }
                    public string Value3 { get; set; }
                    public Room()
                    {
                        this.Value1 = "one";
                        this.Value2 = "two";
                        this.Value3 = "three";
                    }
                }
                class Building{
                    public Room Room1 { get; set; }
                    public Room Room2 { get; set; }
                    public Building()
                    {
                        this.Room1 = new Room();
                        this.Room2 = new Room();
                    }
                }
                class Street{
                    public Building Building1 { get; set; }
                    public Building Building2 { get; set; }
                    public Building Building3 { get; set; }
                    public Building Building4 { get; set; }
                    public Street()
                    {
                        this.Building1 = new Building();
                        this.Building2 = new Building();
                        this.Building3 = new Building();
                        this.Building4 = new Building();
                    }
                }
        
                public static void Main(string[] args)
                {
                    string SelectedValue = "";
                    Street s = new Street();
                    string buildingPropertyAsString = "Building3";
                    var splittedPath = "s.Building1.Room1.Value1".Split('.');
                    var neededValue =
                        ((s.GetProperty(splittedPath[1]) as Building).GetProperty(splittedPath[2]) as Room).GetProperty(
                            splittedPath[3]) as string;
                }
            }
            public static class TypeExtentions
            {
                public static object GetProperty(this object o, string member)
                {
                    if (o == null) throw new ArgumentNullException("o");
                    if (member == null) throw new ArgumentNullException("member");
                    Type scope = o.GetType();
                    IDynamicMetaObjectProvider provider = o as IDynamicMetaObjectProvider;
                    if (provider != null)
                    {
                        ParameterExpression param = Expression.Parameter(typeof(object));
                        DynamicMetaObject mobj = provider.GetMetaObject(param);
                        GetMemberBinder binder = (GetMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.GetMember(0, member, scope, new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(0, null) });
                        DynamicMetaObject ret = mobj.BindGetMember(binder);
                        BlockExpression final = Expression.Block(
                            Expression.Label(CallSiteBinder.UpdateLabel),
                            ret.Expression
                            );
                        LambdaExpression lambda = Expression.Lambda(final, param);
                        Delegate del = lambda.Compile();
                        return del.DynamicInvoke(o);
                    }
                    else {
                        return o.GetType().GetProperty(member, BindingFlags.Public | BindingFlags.Instance).GetValue(o, null);
                    }
                }
            }
        }
