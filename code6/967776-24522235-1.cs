        @inherits Umbraco.Web.Mvc.UmbracoTemplatePage
        @{
            Layout = "ContentPageLayout.cshtml";
        }
        @* Call GetPriceList on PriceListController with Parameter contentTitle *@
        @Html.Action("GetPriceList", "PriceListSurface", new { contentTitle =     Model.Content.GetPropertyValue<string>("ContentTitle") });
