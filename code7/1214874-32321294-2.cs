    	RuntimeType runtimeType;
			if (this.IsInstanceOfType(value))
			{
				Type type = null;
				RealProxy realProxy = RemotingServices.GetRealProxy(value);
				type = (realProxy == null ? value.GetType() : realProxy.GetProxiedType());
				if (type == this || !RuntimeTypeHandle.IsValueType(this))
				{
					return value;
				}
				return RuntimeType.AllocateValueType(this, value, true);
			}
			if (!base.IsByRef)
			{
				if (value == null)
				{
					return value;
				}
				if (this == RuntimeType.s_typedRef)
				{
					return value;
				}
			}
