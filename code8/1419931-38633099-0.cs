        public class MyTemplateSelector: DataTemplateSelector
        {
            public DataTemplate VIPTemplate { get; set; }//DataTemplate for special user
            public DataTemplate CustomerTemplate { get; set; }//DataTemplate for normal user
            protected override DataTemplate SelectTemplateCore(object item)
            {
                if (((Customer)item).Id.ToLower() == "vipcustomer")
                {
                    //if current user is vip then user VIP Template.
                    return VIPTemplate;
                }
                else
                {
                    //otherwise return normal template.
                    return CustomerTemplate;
                }
            }
        }
