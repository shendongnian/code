    <ul id="tabsMore">
      @if (Model.IsLink)
      {
        <li><a href="@Url.Action(Model.LinkAction, new { linkId = Model.ID })">
        @Model.DisplayName<span>&nbsp;</span></a></li>
      }
      else
      {
        <li><a href="@Url.Action(Model.LinkAction, new { clientID = Model.ID })">
        @Model.DisplayName<span>&nbsp;</span></a></li>
      }
    </ul>
