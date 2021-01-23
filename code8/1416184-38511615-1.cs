            //in your class
            private readonly List<DtoObject> _ls = new List<DtoObject>();
            private int _currentIndex = 0;
            private void LoadDto(DtoObject object)
            {
                FirstName.Text = reader["Initial"].ToString();
                LastName.Text = reader["Surname"].ToString();
                ...
                BoilerMod.Text = reader["Model"].ToString();
            }
            private void MoveToNextItem()
            {
              _currentIndex++;
              LoadDtoObject(_ls[_currentIndex]);
            }
            private void MoveToPreviousItem()
            {
              _currentIndex--;
              LoadDtoObject(_ls[_currentIndex]);
            }
