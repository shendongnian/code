    var curPhone = new MobileInfo();
            curPhone.MobileName = "iphone";
            curPhone.MobileOS = "ios";
            TypeDescriptor.AddAttributes(typeof(MobileInfo), new simpleAttribute());
            AttributeCollection collection = TypeDescriptor.GetAttributes(curPhone);
            simpleAttribute attr = ((simpleAttribute)collection[typeof(simpleAttribute)]);
            if (attr != null)
            {
                attr.MobileModul = "s6";
                //MessageBox.Show(attr.MobileModul);
            }   
 
        }
        public class simpleAttribute : Attribute
        {
            public string MobileModul { get; set; }
      
        }
