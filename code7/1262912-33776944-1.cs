    if (!Double.IsNaN(DataContainer.GetValue(ColKeyId, index)))
    {
        if (Convert.ToDecimal(DataContainer.GetValue(ColKeyId, index)) != Convert.ToDecimal(newValueToSet))
        {
            DataContainer.SetValue(ColKeyId, index, newValueToSet);
        }
    }
