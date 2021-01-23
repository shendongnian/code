            var user = new Mock<ClaimsPrincipal>();
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = user.Object
                }
            };
