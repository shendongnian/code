    public static class Helper
    {
        public static HtmlString RenderField(
          this SC.Mvc.Helpers.SitecoreHelper sitecoreHelper,
          string fieldNameOrId,
          bool disableWebEdit = false,
          SC.Collections.SafeDictionary<string> parameters = null)
        {
            if (parameters == null)
            {
                parameters = new SC.Collections.SafeDictionary<string>();
            }
            return sitecoreHelper.Field(
              fieldNameOrId,
              new
                {
                    DisableWebEdit = disableWebEdit,
                    Parameters = parameters
                });
        }
        public static HtmlString RenderField(
          this SC.Mvc.Helpers.SitecoreHelper sitecoreHelper,
          SC.Data.ID fieldId,
          bool disableWebEdit = false,
          SC.Collections.SafeDictionary<string> parameters = null)
        {
            return RenderField(
              sitecoreHelper,
              fieldId.ToString(),
              disableWebEdit,
              parameters);
        }
        public static HtmlString RenderDate(
          this SC.Mvc.Helpers.SitecoreHelper sitecoreHelper,
          string fieldNameOrId,
          string format = "D",
          bool disableWebEdit = false,
          bool setCulture = true,
          SC.Collections.SafeDictionary<string> parameters = null)
        {
            if (setCulture)
            {
                Thread.CurrentThread.CurrentUICulture =
                  new CultureInfo(SC.Context.Language.Name);
                Thread.CurrentThread.CurrentCulture =
                  CultureInfo.CreateSpecificCulture(SC.Context.Language.Name);
            }
            if (parameters == null)
            {
                parameters = new SC.Collections.SafeDictionary<string>();
            }
            parameters["format"] = format;
            return RenderField(
              sitecoreHelper,
              fieldNameOrId,
              disableWebEdit,
              parameters);
        }
        public static HtmlString RenderDate(
          this SC.Mvc.Helpers.SitecoreHelper sitecoreHelper,
          SC.Data.ID fieldId,
          string format = "D",
          bool disableWebEdit = false,
          bool setCulture = true,
          SC.Collections.SafeDictionary<string> parameters = null)
        {
            return RenderDate(
              sitecoreHelper,
              fieldId.ToString(),
              format,
              disableWebEdit,
              setCulture,
              parameters);
        }
        public static HtmlString TagField(
          this SC.Mvc.Helpers.SitecoreHelper sitecoreHelper,
          string fieldNameOrId,
          string htmlElement,
          bool disableWebEdit = false,
          SC.Collections.SafeDictionary<string> parameters = null)
        {
            SC.Data.Items.Item item =
              SC.Mvc.Presentation.RenderingContext.Current.ContextItem;
            if (item == null || String.IsNullOrEmpty(item[fieldNameOrId]))
            {
                return new HtmlString(String.Empty);
            }
            string value = sitecoreHelper.RenderField(
              fieldNameOrId,
              disableWebEdit,
              parameters).ToString();
            return new HtmlString(String.Format(
              "<{0}>{1}</{0}>",
              htmlElement,
              value));
        }
        public static HtmlString TagField(
          this SC.Mvc.Helpers.SitecoreHelper sitecoreHelper,
          SC.Data.ID fieldId,
          string htmlElement,
          bool disableWebEdit = false,
          SC.Collections.SafeDictionary<string> parameters = null)
        {
            return TagField(
              sitecoreHelper,
              fieldId.ToString(),
              htmlElement,
              disableWebEdit,
              parameters);
        }
    }
