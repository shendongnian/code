    public class CustomCurrencyManager : CurrencyManager
    {
        private bool isEndEditSuspended;
        public override void EndCurrentEdit()
        {
            EndCurrentEdit(false);
        }
        public override void EndCurrentEdit(bool force)
        {
            if (!force)
            { return; }
            // implementation
        }
    }
