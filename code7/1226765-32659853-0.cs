      @using System.Collections
      @model MVCApp.Controllers.KeywordGroup
      @{
         Layout = "";
      }
      @using (Html.BeginForm
              (
                  "_KeywordGroupCreate",
                  "Keyword",
                  new { url = Request.Url.AbsolutePath },
                  FormMethod.Post,
                  new { id = "keywordGroupCreateForm" }
              )
          )
      {
         ...
      }
