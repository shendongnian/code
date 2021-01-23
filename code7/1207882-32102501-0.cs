    using System;
    using System.Linq;
    using Mono.Cecil;
    ...
    if (definition.IsOut)
    {
        // There is an `out` modifier.
    }
    else if (definition.ParameterType.IsByReference)
    {
        // There is a `ref` modifier.
    }
    else if (definition.CustomAttributes.Any(attribute => 
        attribute.AttributeType.FullName == typeof(ParamArrayAttribute).FullName))
    {
        // There is a `params` modifier.
    }
    else
    {
        // There are no modifiers.
    }
