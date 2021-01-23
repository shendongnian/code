    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    namespace Labels
    {
    class Program
    {
        static void Main(string[] args)
        {
            Container c = new Container();
            c.ApplyLabels();
        }
    }
    public class A
    {
    }
    public class B
    {
    }
    public class C
    {
    }
    public class Container
    {
        private Label LabelA = new Label ();
        private Label LabelB = new Label ();
        private Label LabelC = new Label ();
        private List<A> _listA = new List<A> ();
        private List<B> _listB = new List<B> ();
        private List<C> _listC = new List<C> ();
        
        public void ApplyLabels ()
        {
            var allFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Dictionary<Type, FieldInfo> listFields = new Dictionary<Type, FieldInfo>();
            Dictionary<Type, FieldInfo> labelMappings = new Dictionary<Type, FieldInfo>();
            Dictionary<string, Type> namespacesForListGenericTypes = new Dictionary<string, Type>();
            List<FieldInfo> possibleLabelFields = new List<FieldInfo>();
            foreach (var field in allFields)
            {
                if (field.FieldType.IsGenericType)
                {
                    var genericTypeDef = field.FieldType.GetGenericTypeDefinition();
                    if (genericTypeDef == typeof (List<>))
                    {
                        var genericArgument = field.FieldType.GetGenericArguments()[0];
                        listFields.Add(genericArgument, field); // remember list fields and for each list what generic type it has!
                        namespacesForListGenericTypes[genericArgument.Name] = genericArgument;
                    }
                }
                else if (typeof (Label).IsAssignableFrom (field.FieldType))
                {
                    possibleLabelFields.Add(field);
                }
            }
            foreach (var possible in possibleLabelFields)
            {
                if (possible.Name.Length < 6) continue;
                var typeName = possible.Name.Substring(5);
                Type genericListType;
                if (namespacesForListGenericTypes.TryGetValue (typeName, out genericListType))
                {
                    labelMappings[genericListType] = possible;
                }
            }
            foreach (var list in listFields)
            {
                FieldInfo destination;
                if (false == labelMappings.TryGetValue (list.Key, out destination))
                {
                    continue;
                }
                var destinationLabel = destination.GetValue(this) as Label;
                if (destinationLabel == null) continue;
                
                var listValue = list.Value.GetValue(this) as IList;
                var cnt = listValue == null ? 0 : listValue.Count;
                destinationLabel.Text = cnt.ToString();
            }
        }
    }
    public class Label
    {
        public string Text { get; set; }
    }
    }
