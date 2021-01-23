    <script type="text/javascript">
    var ViewBag = {
        IsDesigner: ("@ViewBag.IsDesigner").toLowerCase() === 'true',
        IsAdmin: ("@ViewBag.IsAdmin").toLowerCase() === 'true',
        EmptyGuid: "@ViewBag.EmptyGuid",
        Advertisers_ID: "@ViewBag.Advertisers_ID",
        Primary_Category: "@ViewBag.Primary_Category",
        Primary_Category_ID: "@ViewBag.Primary_Category_ID",
        Advertiser_Name: "@ViewBag.Advertiser_Name",
        Advertiser_NameMM: "@ViewBag.Advertiser_NameMM",
        BookTypeName: "@ViewBag.BookTypeName",
        getAlamatVehicle: {	
            @{
	            int marker_count = 0;
                string markers_str = "";                
                foreach (var item in ViewBag.getAlamatVehicle) 
                {
                    markers_str += "\"" + item.Key + "\": \"" + item.Value + "\"";
                    marker_count++;
                    if (marker_count < ViewBag.getAlamatVehicle.Count)
                    {
                        markers_str += ", ";
                    }
	            }
                var html_str = new HtmlString(markers_str);
            }
            @html_str
        }
	}
    console.log(ViewBag.getAlamatVehicle);
    </script>
