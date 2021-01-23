     public async override Task<bool> CanClose()
        {
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                var screen = Items[i] as ViewModelBase;
                var canclose = await screen.CanClose();
                if (!canclose) return false;
                Items.Remove(screen);//remove it from the tabs so it's not visible anymore
            }
            return true;
        }
