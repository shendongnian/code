            case ActivationKind.PickSaveFileContinuation:
                var fileSavePickerPage = rootFrame.Content as IFileSavePickerContinuable;
                if (fileSavePickerPage != null)
                {
                    fileSavePickerPage.ContinueFileSavePicker(args as FileSavePickerContinuationEventArgs);
                }
                break;
            case ActivationKind.PickFolderContinuation:
                var folderPickerPage = rootFrame.Content as IFolderPickerContinuable;
                if (folderPickerPage != null)
                {
                    folderPickerPage.ContinueFolderPicker(args as FolderPickerContinuationEventArgs);
                }
                break;
            case ActivationKind.WebAuthenticationBrokerContinuation:
                var wabPage = rootFrame.Content as IWebAuthenticationContinuable;
                if (wabPage != null)
                {
                    wabPage.ContinueWebAuthentication(args as WebAuthenticationBrokerContinuationEventArgs);
                }
                break;
        }
