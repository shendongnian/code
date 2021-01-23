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
            var allListFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Dictionary<Type, FieldInfo> listFields = new Dictionary<Type, FieldInfo>();
            Dictionary<Type, FieldInfo> labelMappings = new Dictionary<Type, FieldInfo>();
            foreach (var field in allListFields)
            {
                if (field.FieldType.IsGenericType)
                {
                    var genericTypeDef = field.FieldType.GetGenericTypeDefinition();
                    if (genericTypeDef == typeof (List<>))
                    {
                        var genericArgument = field.FieldType.GetGenericArguments()[0];
                        listFields.Add(genericArgument, field); // remember list fields and for each list what generic type it has!
                    }
                   
                }
                else if (typeof (Label).IsAssignableFrom (field.FieldType))
                {
                    // it is a label!
                    // get label type!
                    var type = Type.GetType("Labels." + field.Name.Substring(5));
                    if (type != null)
                    {
                        labelMappings.Add(type, field);
                    }
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
                destinationLabel.Text = listValue.Count.ToString ();
            }
            
        }
    }
   
    public class Label
    {
        public string Text { get; set; }
    }
    }
