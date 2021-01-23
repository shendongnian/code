    public abstract class WizardViewModel {
        protected WizardViewModel() {
            // this --> points the child class
            ViewModelBinder.Bind(this, new WizardView(), null);
        }
    }
