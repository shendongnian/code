    @model FuncaoUsuario
    
    @using (Html.BeginCollectionItem("ProductDevelopment")) 
    {  
           
        List<SelectListItem> listValues = new List<SelectListItem>();
        if (!string.IsNullOrEmpty(this.Model.Usuario))
        {
            listValues.Add(new SelectListItem { Selected = true, Text = this.Model.Usuario, Value = this.Model.Usuario });
        }
          
        @Html.HiddenFor(x => x.IdFuncao)
        @Html.EditorFor(x => x.Usuario, "Usuario")    
    }
