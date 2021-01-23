    // ViewModel for a single selectable entry
    public class ProjectAndNeighbourhoodListItemViewModel {
        public string ProjectName { get; set; }
        public long NeighbourhoodId { get; set; }
        public bool IsSelected { get; set; }
        public SelectListItem ToSelectListItem() {
            return new SelectListItem {
                Text = ProjectName,
                Value = NeighbourhoodId.ToString(),
                Selected = IsSelected
            }
        }
    }
