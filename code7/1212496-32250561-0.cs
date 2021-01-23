    public class ViewModel : NotifyPropertyChangedImpl
    {
        private string property1;
        private string property2;
    
        public List<String> DataModelProperties { get; set; }
    
        public List<DataModel> DataModelList { get; set; }
    
        public string Property1
        {
            get
            {
                return property1;
            }
            set
            {
                if (property1 != value)
                {
                    property1 = value;
                    SetDynamicDescriptions();
                }
            }
        }
    
        public string Property2
        {
            get
            {
                return property2;
            }
            set
            {
                if (property2 != value)
                {
                    property2 = value;
                    SetDynamicDescriptions();
                }
            }
        }
    
        public ViewModel()
        {
            DataModelList = new List<DataModel>();
    
            DataModelList.Add(new DataModel() { Name = "Name1", Code = "Code1", Desc = "Desc1" });
            DataModelList.Add(new DataModel() { Name = "Name2", Code = "Code2", Desc = "Desc2" });
            DataModelList.Add(new DataModel() { Name = "Name3", Code = "Code3", Desc = "Desc3" });
    
            DataModelProperties = typeof(DataModel).GetProperties().Select(s => s.Name).ToList();
        }
    
        private void SetDynamicDescriptions()
        {
            PropertyInfo propertyInfo1;
            PropertyInfo propertyInfo2;
    
            Type type = typeof(DataModel);
    
            if (!String.IsNullOrEmpty(property1) && !String.IsNullOrEmpty(property2))
            {
                propertyInfo1 = type.GetProperty(property1);
                propertyInfo2 = type.GetProperty(property2);
    
                foreach (DataModel dataModel in DataModelList)
                {
                    dataModel.DynamicDescription = String.Format("{0} - {1}",
                        propertyInfo1.GetValue(dataModel, null), propertyInfo2.GetValue(dataModel, null));
                }
            }
        }
    }
