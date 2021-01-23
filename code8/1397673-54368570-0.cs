     if (rendering.RenderingItem.InnerItem["Path"] == null || string.IsNullOrEmpty(rendering.RenderingItem.InnerItem["Path"]))
                {
                    PipelineService.Get().RunPipeline<RenderRenderingArgs>("mvc.renderRendering", new RenderRenderingArgs(rendering, writer));
                }
                else
                {
                    ViewData.Model = rendering.Model;
                    var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, rendering.RenderingItem.InnerItem["Path"]);
                    var viewContext = new ViewContext(controllerContext, viewResult.View,
                                                 ViewData, TempData, writer);
                    viewContext.ViewBag.renderingUniqueId = rendering.UniqueId;
                    viewResult.View.Render(viewContext, writer);
                }
 
