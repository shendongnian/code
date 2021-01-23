    @model IEnumerable<EditImageViewModel>
    @using(Html.BeginForm("UpdateImage","Controller",FormMethod.Post))
    {
        @for(int i=0;i<Model.Count();i++)
        {
            <img src="@Model[i].ImageUrl"/>
            <textarea name="@string.Format("ImageDes[{0}]", i)">@Model[i].imageDes</textarea>
          <input type="radio" name="@string.Format("IsCoverPic[{0}]", i)" value="@Model[i].IsCoverPic" > 
    
        }
        <button type="submit" class="update" value="Update"></button>
    }
