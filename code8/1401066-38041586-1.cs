    public class DataContext
    {       
        public List<Model1> Bind_Dropdown()
        {
            List<Model1> modellist = new List<Model1> { new Model1 {drpid="1", drpname= "Mumbai"},
                                              new Model1 {drpid="2", drpname= "Bangalore"}};           
            return modellist;
        }
    }
