    /// <summary>
    ///     Searches the controller for the correct action. Prioritizes FormAction attributed Actions first.
    ///     Then searches via Method Code
    /// </summary>
    public class FormActionActionInvoker : AsyncControllerActionInvoker
    {
        protected override ActionDescriptor FindAction(ControllerContext controllerContext,
            ControllerDescriptor controllerDescriptor, string actionName)
        {
            foreach (var mi in controllerDescriptor.ControllerType.GetMethods())
            {
                //Searches for the form action attribute first. And if it is present, then it looks
                //checks to see if the request is valid. This hpens BEFORE it checks the action name
                //which now means ActionName becomes obsolete
                var fa =
                    mi.GetCustomAttributes(false).FirstOrDefault(x => x is FormActionAttribute) as FormActionAttribute;
                if (fa == null)
                    continue;
                if (FormActionAttribute.GetAction(controllerContext) != null &&
                    fa.IsValidForRequest(controllerContext, mi))
                    return new ReflectedActionDescriptor(mi, actionName, controllerDescriptor);
            }
            ActionDescriptor ad = base.FindAction(controllerContext, controllerDescriptor, actionName);
            var rad = ad as ReflectedActionDescriptor;
            if (rad == null)
                return ad;
            //Here we have to check that the form action attibute isn't in required mode. If it is
            //and the form-action is null then we should return null
            var formA =
                rad.MethodInfo.GetCustomAttributes(false).FirstOrDefault(x => x is FormActionAttribute) as
                    FormActionAttribute;
            if (formA != null && FormActionAttribute.GetAction(controllerContext) == null &&
                formA.Mode == FormActionMode.Required)
                return null;
            return rad;
        }
    }
