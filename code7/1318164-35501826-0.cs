    // Set controls for an action
    public void SetControl(EControls control, Action action) {
        switch (control) {
            // If either TilePressed or Released was given, set them both to the same key
            case EControls.TilePressed:
            case EControls.TileReleased:
                //Here Action(...) is DoSomething(...) from the example code
                _controls[EControls.TilePressed] = action.SetActionType(Action.EActionType.PressOnce);
                _controls[EControls.TileReleased] = action.SetActionType(Action.EActionType.ReleaseOnce);
                break;
            case EControls.TileFlagPressed:
            case EControls.TileFlagReleased:
                _controls[EControls.TileFlagPressed] = action.SetActionType(Action.EActionType.PressOnce);
                _controls[EControls.TileFlagReleased] = action.SetActionType(Action.EActionType.ReleaseOnce);
                break;
            case EControls.GameEscape:
                _controls[EControls.GameEscape] = action.SetActionType(Action.EActionType.ReleaseOnce);
                break;
            default:
                throw new ArgumentOutOfRangeException("control");
        }
    }
