    var controllerContext = new HttpControllerContext {
      Request = new HttpRequestMessage {
        Content = new MultipartContent {
          new ByteArrayContent( /* bytes in the file */ )
        }
      }
    };
    var controller = new MyController();
    controller.ControllerContext = controllerContext;
