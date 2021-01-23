    internal static IActionResult CreateActionResult(Type declaredReturnType, object actionReturnValue)
    {
        if (declaredReturnType == null)
        {
            throw new ArgumentNullException(nameof(declaredReturnType));
        }
        // optimize common path
        var actionResult = actionReturnValue as IActionResult;
        if (actionResult != null)
        {
            return actionResult;
        }
        if (declaredReturnType == typeof(void) ||
            declaredReturnType == typeof(Task))
        {
            return new EmptyResult();
        }
        // Unwrap potential Task<T> types.
        var actualReturnType = GetTaskInnerTypeOrNull(declaredReturnType) ?? declaredReturnType;
        if (actionReturnValue == null &&
            typeof(IActionResult).GetTypeInfo().IsAssignableFrom(actualReturnType.GetTypeInfo()))
        {
            throw new InvalidOperationException(
                Resources.FormatActionResult_ActionReturnValueCannotBeNull(actualReturnType));
        }
        return new ObjectResult(actionReturnValue)
        {
            DeclaredType = actualReturnType
        };
    }
