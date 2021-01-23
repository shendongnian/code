    var httpCaches = controllers.SelectMany(controller =>
        controller.Actions.Select(action =>
            new
            {
                Controller = controller,
                Action = action
            })
        )
        .ToDictionary(
            item => item.Controller.Name + "." + item.Action.Name,
            item => item.Action.HttpCache);
