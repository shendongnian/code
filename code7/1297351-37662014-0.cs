    GroupHeaderBand band = XtraReportToPreview.Bands[BandKind.GroupHeader] as GroupHeaderBand;
    if (band != null)
    {
            band.GroupFields.Clear();
            band.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] 
            {
    		// Set your condition for dynamic group by for each GroupField 
            new DevExpress.XtraReports.UI.GroupField("Customer", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)
            });
    }
