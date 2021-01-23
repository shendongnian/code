    @model IList<CyberSystems.UI.Controllers.System.PurchaseOrderControllers.PurchaseOrderController.Order>
               @for (int i = 0; i < Model.Count; i++)
               {
                   @Html.TextBoxFor(c=>Model[i].OrderName)
                   
                       for (int ii = 0; ii < Model[i].OrderItems.Count; ii++)
    
                       {
                           @Html.TextBoxFor(c=>Model[i].OrderItems[@ii].ItemName)
                       }
                   
               }
