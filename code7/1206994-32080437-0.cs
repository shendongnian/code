    public partial class UserControls_ucStateDropDownList : System.Web.UI.UserControl
    {
        private StatesDisplayedInControl m_statesToDisplay;
        /// <summary>
        /// Existing options are as follows:
        ///     - UnitedStates (US states only)
        ///     - Canada (CDN states only)
        ///     - All (All states available)
        /// Default setting is 'All'.   
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public StatesDisplayedInControl StatesDisplayed 
        {
            get { return m_statesToDisplay; }
            set { m_statesToDisplay = value; }
        }
    }
    public enum StatesDisplayedInControl : int
    {
        UnitedStates = 0,
        Canada = 1,
        All = 2
    }
