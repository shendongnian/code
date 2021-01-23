    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Artem.Google.UI;
     public partial class GmapRepeater : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            // Provide data source to repeater control from database.
            rptMarkers.DataSource = DatabaseMapData;
            rptMarkers.DataBind();
        }
    }
    protected void rptMarkers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GoogleMap GMap = (GoogleMap)e.Item.FindControl("GMap");
            GMap.MapType = Artem.Google.UI.MapType.Roadmap;
            GMap.ApiVersion = "v2";
            GMap.Latitude = Convert.ToDouble("-33.939923");
            GMap.Longitude = Convert.ToDouble("151.175276");
            GMap.Zoom = 18;
            GMap.EnableMapTypeControl = false;
            GMap.Height = 200;
            GMap.Width = 195;
            Marker loMarker = new Marker();
            loMarker.Position.Latitude = Convert.ToDouble("-33.939923");
            loMarker.Position.Longitude = Convert.ToDouble("151.175276");
            loMarker.Clickable = true;
            loMarker.Info = "Marker Information";
            loMarker.Title = "Title of your Marker";
            loMarker.Visible = true;
            GMap.Markers.Add(loMarker);
        }
    }
    }
