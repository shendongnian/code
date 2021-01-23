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
            GetData();
        }
    }
    protected void rptMarkers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Markers loData = (Markers)e.Item.DataItem;
            GoogleMap GMap = (GoogleMap)e.Item.FindControl("GMap");
            GMap.MapType = Artem.Google.UI.MapType.Roadmap;
            GMap.ApiVersion = "v2";
            GMap.Latitude = Convert.ToDouble(loData.Latitude);
            GMap.Longitude = Convert.ToDouble(loData.Longitude);
            GMap.Zoom = 18;
            GMap.EnableMapTypeControl = false;
            GMap.Height = 200;
            GMap.Width = 195;
            Marker loMarker = new Marker();
            loMarker.Position.Latitude = Convert.ToDouble(loData.Latitude);
            loMarker.Position.Longitude = Convert.ToDouble(loData.Longitude);
            loMarker.Clickable = true;
            loMarker.Info = "Marker Information";
            loMarker.Title = "Title of your Marker";
            loMarker.Visible = true;
            GMap.Markers.Add(loMarker);
        }
    }
     private void GetData()
    {
        XmlDataDocument xmlDataDoc = new XmlDataDocument();
        xmlDataDoc.Load(Server.MapPath("~/Files/XMLFile.xml"));
        List<Markers> markers = new List<Markers>();
        foreach (XmlNode n in xmlDataDoc.DocumentElement.GetElementsByTagName("Property"))
        {
            if (n.HasChildNodes)
            {
                foreach (XmlNode childNode in n)
                {
                    if (childNode.Name == "GEOData")
                    {
                        Markers loObj = new Markers();
                        loObj.City = Convert.ToString(childNode.Attributes["City"].Value);
                        loObj.Longitude = Convert.ToString(childNode.Attributes["Longitude"].Value);
                        loObj.Latitude = Convert.ToString(childNode.Attributes["Latitude"].Value);
                        markers.Add(loObj);
                    }
                }
            }
        }
        if (markers != null && markers.Count > 0)
        {
            rptMarkers.DataSource = markers;
            rptMarkers.DataBind();
        }
    }
    }
