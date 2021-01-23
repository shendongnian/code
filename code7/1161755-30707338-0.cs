    public class MyObject:XPObject
    {
        protected override void OnSaving()
        {
           if(this.Session.IsNewObject(this)
                 //SetDefaultValues
           base.OnSaving();
         }
    }
