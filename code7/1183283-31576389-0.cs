    /// <summary>
    /// Used in CellStyleSelector and its inheriting classes.
    /// 
    /// Wouldnt be too hard to modify to allow declarative if highly desired.
    /// 
    /// NOTE - tried extending telerik.StyleRule, issues with setting condition value
    /// </summary>
    public class CellStyleRule
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
        Style _Style;
        public Style Style
        {
            get
            {
                return this._Style;
            }
            set
            {
                this._Style = value;
            }
        }
        public CellStyleRule(Expression<Func<BaseDataModel, bool>> c, string s)
        {
            var d = App.Current.FindResource(s);
            if (d != null)
                this.Style = d as Style;
            else
                throw new Exception("No such style resource as '" + s + "'");
            // Value = v;
            Condition = c;
        }
        /*
        public CellStyleRule(string c, string s)
        {
            var d = App.Current.FindResource(s);
            if (d != null)
                Style = d as Style;
            else
                throw new Exception("No such style resource as '" + s + "'");
            // TODO - test - guessing at how to do this based on telerik classes
            // Value = v;
            Telerik.Windows.Data.ExpressionTypeConverter converter = new Telerik.Windows.Data.ExpressionTypeConverter();
            Condition = (System.Linq.Expressions.Expression) converter.ConvertFromString(c);
            c.ToString();
        }
         */
    }
    
    // NOTE IMPORTANT - use of xaml defined ConditionalStyleSelectors is not a bad alternative approach, though diferent selector
    //                  for each column it could all be defined in same resource dictionary
    //                - problem is that issues encountered with Enums, so decided on this approach instead
    /// <summary>
    /// A variation of StyleSelecter not unlike telerik:ConditionalStyleSelector. 
    /// 
    /// However, rules are defined using a Dictionary<string,CellStyle> to distinct columns and use same 
    /// selector, with rules (currently) defined not declarativly (xaml), but in inheriting classes, 
    /// typically one for each entity type requiring a RadGridView and conditional styling.
    /// </summary>
    public abstract class CellStyleSelector : StyleSelector
    {
        // public Dictionary<String, Dictionary<string, Style>> conditions { get; set; }
        // Use a Dictionary mapping X columns to individual Lists of rules to check
        Dictionary<string, List<CellStyleRule>> _Rules;
        public Dictionary<string, List<CellStyleRule>> Rules
        {
            get
            {
                if (this._Rules == null)
                {
                    this._Rules = new Dictionary<string, List<CellStyleRule>>();
                }
                return this._Rules;
            }
            set { this._Rules = value; }
        }
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is BaseDataModel)
            {
                GridViewCell cell = container as GridViewCell;
                var currentColumn = cell.Column as GridViewDataColumn;
                string key = currentColumn.DataMemberBinding.Path.Path;
                if (Rules.ContainsKey(key))
                {
                    foreach (CellStyleRule rule in Rules[key])
                    {
                        // string debug = DebugHelper.Debug(rule.Condition);
                        // REVERTED NOTE - if just Func<>
                        // if (rule.Condition((BaseDataModel)item))
                        // NOTE - if Expression<Func<>>, first compile then pass in param
                        if (rule.Condition.Compile()((BaseDataModel)item))
                        {
                            return rule.Style;
                        }
                    }
                }
            }
            return null;
        }
    }
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
    // Implementing class, used for any licence table
    public class LicenceTableCellStyleSelector : CellStyleSelector
    {
        public LicenceTableCellStyleSelector()
            : base()
        {
            this.Rules = new Dictionary<string, List<CellStyleRule>>()
            {
                { "LicenceStatus" , new List<CellStyleRule>()
                    {
                        // Always most specific rules at top
                        // Error catcher, leave in as visual cue just in case
                        { new CellStyleRule(x => ((Licence)x).LicenceExpires < DateTime.Now && ((Licence)x).LicenceStatus != LicenceStatus.Expired, "CellStyle_Licence_ExpiryMismatch") } ,
                        { new CellStyleRule(x => ((Licence)x).LicenceStatus == LicenceStatus.Active, "CellStyle_Status_Active") } ,
                        // Same as != Active, as only those would through this far
                        { new CellStyleRule(x => x != null, "CellStyle_Status_Inactive") } ,
                    }
                },
                
                { "LicenceType" , new List<CellStyleRule>()
                    {                        
                        { new CellStyleRule(x => ((Licence)x).LicenceType == LicenceType.Full, "CellStyle_Licence_Full") } ,
                        { new CellStyleRule(x => ((Licence)x).LicenceType == LicenceType.Upgrade, "CellStyle_Licence_Upgrade") } ,
                        // Timed, uses fallthrough so no need to actually check unless wanting to distinct types of timed
                        { new CellStyleRule(x => x != null, "CellStyle_Licence_Timed") } ,
                    }
                },
                { "LicenceExpired" , new List<CellStyleRule>()
                    {                        
                        { new CellStyleRule(x => ((Licence)x).LicenceExpires < DateTime.Now && ((Licence)x).LicenceStatus != LicenceStatus.Expired, "CellStyle_Licence_ExpiryMismatch")  }, 
                        { new CellStyleRule(x => ((Licence)x).LicenceExpires < ((Licence)x).LicenceIssued, "CellStyle_Licence_ExpiryMismatch") } ,
                    }
                },
                
                { "LicenceIssued" , new List<CellStyleRule>()
                    {
                        { new CellStyleRule(x => ((Licence)x).LicenceExpires < ((Licence)x).LicenceIssued, "CellStyle_Licence_ExpiryMismatch") } ,
                    }
                }
            };
        }
    }
