    /// <summary>
    /// Used in CellCellTemplateRuleSelector and its inheriting classes.
    /// 
    /// Wouldnt be too hard to modify to allow declarative if highly desired.
    /// </summary>
    public class CellTemplateRule
    {
        /*
        object _Value;
        public object Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }
         */
        // NOTE - if needing to widen use case, use <T>, but ONLY if needed
        Expression<Func<BaseDataModel, bool>> _Condition;
        public Expression<Func<BaseDataModel, bool>> Condition
        {
            get
            {
                return this._Condition;
            }
            set
            {
                this._Condition = value;
            }
        }
        DataTemplate _Template;
        public DataTemplate Template
        {
            get
            {
                return this._Template;
            }
            set
            {
                this._Template = value;
            }
        }
        public CellTemplateRule(Expression<Func<BaseDataModel, bool>> c, string s)
        {
            var d = App.Current.FindResource(s);
            if (d != null)
                this.Template = d as DataTemplate;
            else
                throw new Exception("No such template resource as '" + s + "'");
            Condition = c;
        }
    }
    
    // NOTE IMPORTANT - use of xaml defined ConditionalTemplateSelectors is not a bad alternative approach, though diferent selector
    //                  for each column it could all be defined in same resource dictionary
    //                - problem is that issues encountered with Enums, so decided on this approach instead
    /// <summary>
    /// See CellStyleSelector, this is a variant used with the CellTemplateSelector property
    /// </summary>
    public abstract class CellTemplateSelector : DataTemplateSelector
    {
        // public Dictionary<String, Dictionary<string, Template>> conditions { get; set; }
        // Use a Dictionary mapping X columns to individual Lists of rules to check
        Dictionary<string, List<CellTemplateRule>> _Rules;
        public Dictionary<string, List<CellTemplateRule>> Rules
        {
            get
            {
                if (this._Rules == null)
                {
                    this._Rules = new Dictionary<string, List<CellTemplateRule>>();
                }
                return this._Rules;
            }
            set { this._Rules = value; }
        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is BaseDataModel)
            {
                GridViewCell cell = container as GridViewCell;
                var currentColumn = cell.Column as GridViewDataColumn;
                string key = currentColumn.DataMemberBinding.Path.Path;
                if (Rules.ContainsKey(key))
                {
                    foreach (CellTemplateRule rule in Rules[key])
                    {
                        // string debug = DebugHelper.Debug(rule.Condition);
                        // REVERTED NOTE - if just Func<>
                        // if (rule.Condition((BaseDataModel)item))
                        // NOTE - if Expression<Func<>>, first compile then pass in param
                        if (rule.Condition.Compile()((BaseDataModel)item))
                        {
                            return rule.Template;
                        }
                    }
                }
            }
            return null;
        }
    }
    
    // Implementing class for a different table, though RadGridView can use both CellStyleSelector and CellTemplateSelector at same time, i just didnt need yet
    public class OrderDongleWrapTableCellTemplateSelector : CellTemplateSelector
    {
        public OrderDongleWrapTableCellTemplateSelector()
            : base()
        {
            this.Rules = new Dictionary<string, List<CellTemplateRule>>()
            {
                { "ReplacedDongle.DongleID" , new List<CellTemplateRule>()
                    {
                        // Always most specific rules at top
                        { new CellTemplateRule(x => ((OrderDongleWrap)x).IsReplacementDongle == false  , "CellTemplate_OrderDongleWrap_NotReplacementDongler_NAField") },
                    }
                },
                { "ReplacedDongleStatus" , new List<CellTemplateRule>()
                    {
                        // Always most specific rules at top
                        { new CellTemplateRule(x => ((OrderDongleWrap)x).IsReplacementDongle == false  , "CellTemplate_OrderDongleWrap_NotReplacementDongler_NAField") },
                    }
                },
                /*
                 * // REVERTED - better to just set to UNKNOWN CUSTOMER explicitly before shown in table, rather than overwrite datatemplate
                { "Customer.CustomerName" , new List<CellTemplateRule>()
                    {
                        // Always most specific rules at top
                        { new CellTemplateRule(x => ((OrderDongleWrap)x).Customer == null || ((OrderDongleWrap)x).Customer.CustomerID == 1 , "CellTemplate_OrderDongleWrap_UnknownCustomerField") },
                    }
                },
                */
            };
        }
    }
