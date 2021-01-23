    class BaseClass
    {
        protected void Update()
        {
            if(someArgument)
            {
                this.InnerUpdate();
            }
        }
        
        protected virtual void InnerUpdate()
        {
        }
    }
    class Foo : BaseClass
    {
        protected override void InnerUpdate()
        {
            //Some other code
        }
    }
