		#region DropDown to select a table
        [PXDBString(1)]
        [PXUIField(DisplayName = "Table Selection")]
        [PXStringList(
            new string[]
            {
                "A",
                "B",
                "C"
            },
            new string[]
            {
                    "Table A",
                    "Table B",
                    "Table C"
            })]
        public virtual string UsrTableSelection { get; set; }
        public abstract class usrTableSelection : IBqlField
        {
        }
        #endregion
        #region Selector
        [PXDBInt]
        [PXUIField(DisplayName = "Table Selector")]
        [MyCustomSelector(
            typeof(APRegisterExt.usrTableSelection), 
            typeof(TableA.id),typeof(TableA.description),
            typeof(TableB.id), typeof(TableB.description),
            typeof(PX.Objects.AR.Customer.bAccountID), 
            typeof(PX.Objects.AR.Customer.acctName))]
        public virtual int? UsrTableSelector { get; set; }
        public abstract class usrTableSelector : IBqlField
        {
        }
        #endregion
