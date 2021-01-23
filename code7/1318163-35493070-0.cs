	public void SetControl(EControls control, Func<Action.EActionType, Action> createAction)
	{
		switch (control)
		{
			case EControls.TilePressed:
			case EControls.TileReleased:
				_controls[EControls.TilePressed] = createAction(Action.EActionType.PressOnce);
				_controls[EControls.TileReleased] = createAction(Action.EActionType.ReleaseOnce);
				break;
				
			case EControls.TileFlagPressed:
			case EControls.TileFlagReleased:
				_controls[EControls.TileFlagPressed] = createAction(Action.EActionType.PressOnce);
				_controls[EControls.TileFlagReleased] = createAction(Action.EActionType.ReleaseOnce);
				break;
				
			case EControls.GameEscape:
				_controls[EControls.GameEscape] = createAction(Action.EActionType.ReleaseOnce);
				break;
				
			default:
				throw new ArgumentOutOfRangeException("control");
		}
	}
	
	// Call it later with:
	SetControl(control, type => new Action(key, type));
	SetControl(control, type => new Action(mouseButton, type));
