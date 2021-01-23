    public class ExamineExamplesDataGridItem : BasePropertyChanged
    {
        public ExamineExamplesDataGridItem()
        {
            PredictiveAttributeValues = new List<string>();
            PredictiveAttributeValues.Add("Predict 1");
            PredictiveAttributeValues.Add("Predict 2");
            PredictiveAttributeValues.Add("Predict 3");
            PredictiveAttributeValues.Add("Predict 4");
            PredictiveAttributeValues.Add("Predict 5");
        }
        private List<string> _PredictiveAttributeValues;
        public List<string> PredictiveAttributeValues
        {
            get { return _PredictiveAttributeValues; }
            set { _PredictiveAttributeValues = value; NotifyPropertyChanged("PredictiveAttributeValues"); }
        }
        private string _Coll1;
        public string Coll1
        {
            get { return _Coll1; }
            set { _Coll1 = value; NotifyPropertyChanged("Coll1"); }
        }
        private string _Coll2;
        public string Coll2
        {
            get { return _Coll2; }
            set { _Coll2 = value; NotifyPropertyChanged("Coll2"); }
        }
    }
