        private delegate void SetListCallback(List<Course> result);
        private async void GetCourseList() {
            Task<List<Course>> courseTask = MongoDBController.GetCourses();
            List<Course> result = await courseTask.ConfigureAwait(false);
            // When finished, fill the listbox
            FillCourseList(result);
        }
        private void FillCourseList(List<Course> result) {
            // If the calling thread's ID doesn't match the creating thread's ID
            // Invoke this method on the correct thread via the delegate
            if (this.listBox_overview_vakken.InvokeRequired) {
                SetListCallback d = new SetListCallback(FillCourseList);
                this.Invoke(d, result);
            } else {
                foreach (Course s in result) {
                    listBox_overview_vakken.Items.Add(s);
                }
            }
        }
