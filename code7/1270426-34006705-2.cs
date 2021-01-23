    abstract class MasterDoer : IDo
    {
        private bool _disableMake = true;
        private List<string> _ignoreList = new { "a", "b", "c"}
        public IMaker Maker { get; set; }
        protected abstract Task DoStuff(object x);
        public async Task Method1(object x)
        {
            if(disableMake = true && _ignoreList.Contains(x.toString))
                return;
            await Maker.Method1();
        }
        // etc.
    }
---
    class Doer1 : MasterDoer
    {
        protected override async Task DoStuff(object x)
        { 
            await base.Method1(x); 
        }
    }
