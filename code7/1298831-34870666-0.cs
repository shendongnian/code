    var curPhone = new MobileInfo();
            curPhone.MobileName = "iphone";
            curPhone.MobileOS = "mac";
            TypeDescriptor.AddAttributes(typeof(MobileInfo), new simpleAttribute());
            AttributeCollection collection = TypeDescriptor.GetAttributes(curPhone);
            simpleAttribute attr = ((simpleAttribute)collection[typeof(simpleAttribute)]);
            if (attr != null)
            {
                attr.MobileModul = "6s";
                //MessageBox.Show(attr.MobileModul);
            }   
 
        }
        public class simpleAttribute : Attribute
        {
            public string MobileModul { get; set; }
      
        }
