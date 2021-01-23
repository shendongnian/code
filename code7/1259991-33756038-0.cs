    protected void Mark_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DataSetVehicles1TableAdapters.QueriesTableAdapter ds = new DataSetVehicles1TableAdapters.QueriesTableAdapter();
            string mark = args.Value;
            string result = ds.ogpo_specialize_vehicle_select(mark.ToUpper()).ToString();
            if (result == "0")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
