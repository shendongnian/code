            var controller = CreateController<ControllerName>();
            var result = controller.ActionName(param1, param2);
            object viewData = result.GetType().GetProperty("ViewData").GetValue(result);
            object values = viewData.GetType().GetProperty("Values").GetValue(viewData);
            var str = ec.RenderRazorViewToString("ViewName", values);
            return str;
