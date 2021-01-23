    var content = new ByteArrayContent( /* bytes in the file */ );
    content.Headers.Add("Content-Disposition", "form-data");
    var controllerContext = new HttpControllerContext {
      Request = new HttpRequestMessage {
        Content = new MultipartContent { content }
      }
    };
    var controller = new MyController();
    controller.ControllerContext = controllerContext;
