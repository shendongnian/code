    @model IEnumerable<SIGO.Models.TopMenu>
    	<div class="navbar navbar-inverse navbar-fixed-top">
    		<div class="container">
    			<div class="navbar-header">
    				<div class="SigoLogo">
    					<a href="@Url.Action("Index", "Home")" title="Início">
    						<img src="~/Content/images/Wlogo.png" />
    					</a>
    				</div>
    				<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"></button>
    			</div>
    			<div class="navbar-collapse collapse">
    				<ul class="nav navbar-nav">
    					@if (Model != null){
    						foreach(var item in Model.Where(p => p.Parent == 0)) {
    							if (Model.Where(s1 => s1.Parent == item.Id) != null) {
    								<li>@item.Descricao
    									<ul>
    										@foreach (var sub1 in Model.Where(s1 => s1.Parent == item.Id)) {
    											if (Model.Where(s2 => s2.Parent == sub1.Id) != null) {
    												<li>@sub1.Descricao
    													<ul>
    														@foreach (var sub2 in Model.Where(s2 => s2.Parent == sub1.Id)) {
    														<li>@Html.ActionLink(sub2.Descricao,sub2.Action,sub2.Controller)</li>
    														}
    													</ul>
    												</li>
    											}else{
    												<li>@Html.ActionLink(sub1.Descricao,sub1.Action,sub1.Controller)</li>
    											}
    										}
    									</ul>
    								</li>
    							}else{
    								<li>@Html.ActionLink(item.Descricao,item.Action,item.Controller)</li>
    							}
    						}
    					}
    				</ul>
    			</div>
    		</div>
    	</div>
