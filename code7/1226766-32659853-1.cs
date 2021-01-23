      @using System.Collections
      @model MVCApp.Controllers.KeywordGroup
      @{
         Layout = "";
      }
      @using (Html.BeginForm
              (
                  "_KeywordGroupCreate",
                  "Keyword",
                  new { url = Request.Url.AbsoluteUri },
                  FormMethod.Post,
                  new { id = "keywordGroupCreateForm" }
              )
          )
      {
         ...
      }
