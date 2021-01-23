    /// <summary>
    /// Base class for all presenters
    /// </summary>
    public abstract class TerminalPresenterBase : ITerminalPresenter
    {
        protected ITerminalView view;
        public TerminalPresenterBase(ITerminalView view)
        {
            if (view == null) 
                throw new ArgumentNullException("view");
            this.view = view;
            this.Parent = this;
        }
        public abstract void UpdateUI();
        public abstract ITerminalPresenter this[int index]
        {
            get;
        }
        public abstract ITerminalPresenter Do1();
        public abstract ITerminalPresenter Do2();
        public virtual ITerminalPresenter Parent
        {
            get;
            set;
        }
        public virtual void Reset()
        {
            this.UpdateUI();
        }
    }
    /// <summary>
    /// Presenter whose sole goal is to allow user to select some other option and press next
    /// </summary>
    public class SelectOptionPresenter : TerminalPresenterBase
    {
        private IList<KeyValuePair<String, ITerminalPresenter>> options;
        private ITerminalPresenter selected;
        private String title;
        public SelectOptionPresenter(ITerminalView view,
            String title, 
            IList<KeyValuePair<String, ITerminalPresenter>> options)
            : base(view)
        {
            if (options == null)
                throw new ArgumentNullException("options");
            this.title = title;
            this.options = options;
            foreach (var item in options)
            {
                item.Value.Parent = this;
            }
        }
        public override void UpdateUI()
        {
            this.view.Clear();
            this.view.Button1_Text = "Confirm selection";
            this.view.Button2_Text = "Go back";
            this.view.Title = title;
            this.view.SelectionItems = options
                .Select(opt => opt.Key);
        }
        public override ITerminalPresenter this[int index]
        {
            get
            {
                this.selected = this.options[index].Value;
            
                return this;
            }
        }
        public override ITerminalPresenter Do1()
        {
            return this.ConfirmSelection();
        }
        public override ITerminalPresenter Do2()
        {
            return this.GoBack();
        }
        public ITerminalPresenter ConfirmSelection()
        {
            this.selected.UpdateUI();
            return this.selected;
        }
        
        public ITerminalPresenter GoBack()
        {
            this.Parent.UpdateUI();
            return this.Parent;
        }
    }
    public enum APlusBState
    {
        EnterA,
        EnterB,
        Result
    }
    public class StepActions
    {
        public Action UpdateUI { get; set; }
        public Func<ITerminalPresenter> Do1 { get; set; }
        public Func<ITerminalPresenter> Do2 { get; set; }
    }
    public class APlusBPresenter : TerminalPresenterBase
    {
        private Int32 a, b;
        private APlusBState state;
        private String error = null;
        private Dictionary<APlusBState, StepActions> stateActions;
        private void InitializeStateActions()
        {
            this.stateActions = new Dictionary<APlusBState, StepActions>();
            this.stateActions.Add(APlusBState.EnterA,
                new StepActions()
                {
                    UpdateUI = () =>
                    {
                        this.view.Title = this.error ?? "Enter A";
                        this.view.Input = this.a.ToString();
                        this.view.Button1_Text = "Confirm A";
                        this.view.Button2_Text = "Exit";
                    },
                    Do1 = () => // Confirm A
                    {
                        if (!Int32.TryParse(this.view.Input, out this.a))
                        {
                            this.error = "A is in incorrect format. Enter A again";
                            return this;
                        }
                        this.error = null;                     
                        this.state = APlusBState.EnterB;
                        return this;
                    },
                    Do2 = () => // Exit
                    {
                        this.Reset();
                        return this.Parent;
                    }
                });
            
            this.stateActions.Add(APlusBState.EnterB,
                new StepActions()
                {
                    UpdateUI = () =>
                    {
                        this.view.Title = this.error ?? "Enter B";
                        this.view.Input = this.b.ToString();
                        this.view.Button1_Text = "Confirm B";
                        this.view.Button2_Text = "Back to A";
                    },
                    Do1 = () => // Confirm B
                    {
                        if (!Int32.TryParse(this.view.Input, out this.b))
                        {
                            this.error = "B is in incorrect format. Enter B again";
                            return this;
                        }
                        this.error = null;                     
                        this.state = APlusBState.Result;
                        return this;
                    },
                    Do2 = () => // Back to a
                    {
                        this.state = APlusBState.EnterA;
                        return this;
                    }
                });
            this.stateActions.Add(APlusBState.Result,
                new StepActions()
                {
                    UpdateUI = () =>
                    {
                        this.view.Title = String.Format("The result of {0} + {1}", this.a, this.b);
                        this.view.Output = (this.a + this.b).ToString();
                        this.view.Button1_Text = "Exit";
                        this.view.Button2_Text = "Back";
                    },
                    Do1 = () => // Exit
                    {
                        this.Reset();
                        return this.Parent;
                    },
                    Do2 = () => // Back to B
                    {
                        this.state = APlusBState.EnterB;
                        return this;
                    }
                });
        }
        public APlusBPresenter(ITerminalView view) : base(view)
        {
            this.InitializeStateActions();
            this.Reset();
        }
        public override void UpdateUI()
        {
            this.view.Clear();
            this.stateActions[this.state].UpdateUI();
        }
        public override ITerminalPresenter this[int index]
        {
            get { throw new NotImplementedException(); }
        }
        public override ITerminalPresenter Do1()
        {
            var nextPresenter = this.stateActions[this.state].Do1();
            nextPresenter.UpdateUI();
            return nextPresenter;
        }
        public override ITerminalPresenter Do2()
        {
            var nextPresenter = this.stateActions[this.state].Do2();
            nextPresenter.UpdateUI();
            return nextPresenter;
        }
        public override void Reset()
        {
            this.state = APlusBState.EnterA;
            this.a = 0;
            this.b = 0;
            this.error = null;
        }
    }
