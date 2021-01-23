        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String cdts_token_phone
        {
            get
            {
                return cdtsToDT(_cdts_token_phone);
            }
            set
            {
                Oncdts_token_phoneChanging(value);
                ReportPropertyChanging("cdts_token_phone");
                _cdts_token_phone = StructuralObject.SetValidValue(value, true, "cdts_token_phone");
                ReportPropertyChanged("cdts_token_phone");
                Oncdts_token_phoneChanged();
            }
        }
    private string cdtsToDT(string cdtsUT)
        {
            if(string.IsNullOrEmpty(cdtsUT))
                return string.Empty;
            DateTime _newDT = new DateTime(int.Parse(cdtsUT.Substring(0, 4)), int.Parse(cdtsUT.Substring(4, 2)),
                    int.Parse(cdtsUT.Substring(6, 2)), int.Parse(cdtsUT.Substring(8, 2)),
                    int.Parse(cdtsUT.Substring(10, 2)), int.Parse(cdtsUT.Substring(12, 2)));
            string cdts = _newDT.ToString("dd-MM-yyyy HH:mm:ss");
            return cdts;
        }
