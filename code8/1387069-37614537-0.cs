    class ThrowableRenderer : log4net.ObjectRenderer.IObjectRenderer {
      private readonly IObjectRenderer fallback;
      public ThrowableRenderer(RendererMap rendererMap) {
        this.fallback = rendererMap.Get(typeof(Throwable));
      }
      
      public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer) {
        var filteredEnumerable = (obj as IEnumerable)?.Cast<object>().Skip(1);
        if (filteredEnumerable != null) {
          rendererMap.FindAndRender(obj.ToString(), writer);
          if (filteredEnumerable.Any()) {
            writer.WriteLine();
            rendererMap.FindAndRender(filteredEnumerable, writer);
          }
        } else {
          fallback.RenderObject(rendererMap, obj, writer);
        }
      }
    }
  
