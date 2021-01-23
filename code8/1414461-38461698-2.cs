    public class Value
    {        
        public Value()
        {
            ButtonCommand  = new RelayCommand((a) => true, CommandMethod); 
        }
        
        public RelayCommand ButtonCommand {get; set; }
        public string ButtonClickMethod { get; set; }
    
        private void CommandMethod(object obj)
        {
            MessageBox.Show(obj?.ToString());
        }
    }
