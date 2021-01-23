	internal bool PushData(bool force)
	{
		Exception ex = null;
		if (!force && this.ControlUpdateMode == ControlUpdateMode.Never)
		{
			return false;
		}
		if (this.inPushOrPull && this.formattingEnabled)
		{
			return false;
		}
		this.inPushOrPull = true;
		try
		{
			if (this.IsBinding)
			{
				object value = this.bindToObject.GetValue();
				object propValue = this.FormatObject(value);
				this.SetPropValue(propValue);
				this.modified = false;
			}
			else
			{
				this.SetPropValue(null);
			}
		}
		catch (Exception ex2)
		{
			ex = ex2;
			if (!this.FormattingEnabled)
			{
				throw;
			}
		}
		finally
		{
			this.inPushOrPull = false;
		}
		if (this.FormattingEnabled)
		{
			BindingCompleteEventArgs bindingCompleteEventArgs = this.CreateBindingCompleteEventArgs(BindingCompleteContext.ControlUpdate, ex);
			this.OnBindingComplete(bindingCompleteEventArgs);
			return bindingCompleteEventArgs.Cancel;
		}
		return false;
	}
