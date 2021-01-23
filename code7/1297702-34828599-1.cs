            private void IsInEditModeToggleMethod ( )
            {
                this.IsEllipseVisible = true;
                var countryViewModel = ViewModelFinder.FindOne<CountryViewModel>();
                countryViewModel.Countries.Where(x=>x.Id != this.Id).ToList().ForEach(ci => ci.IsVisible = false);
                this.IsInEditMode = !this.IsInEditMode;
                this.AnimateToCenter();
            }
