    interface IWidget 
    {
        public void readData();
    }
    
    class Widget1 : IWidget
    {
        public string Title { get; set; }
        public string TechnicalName { get; set; }
    
        public void readData()
        {
            Console.WriteLine("- Title: {0}\n- Technical name: {1}", Title, TechnicalName);
        }
    }
    
    class Widget2 : IWidget
    {
        public List<int> PickerValues { get; set; }
    
        public void readData()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= PickerValues.Count; i++)
            {
                builder.AppendLine(String.Format("- Range picker field {0}: {1}",i,PickerValues[i-1]));
            }
            Console.WriteLine(builder.ToString());
        }
    }
