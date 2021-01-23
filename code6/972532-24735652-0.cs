    public class EntityViewModel
    {
        public int id { get; set; }
        public int templateId { get; set; }
        public int resourceId { get; set; }
        public int titleId { get; set; }
        public int dow { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
    public interface IEntityConverter
    {
        Entity Convert(ViewModel viewModel);
        ViewModel Convert(Entity entity);
    }
    
    public class EntityConverter
    {
        public Entity Convert(EntityViewModel viewModel)
        {
            return new Entity
            {
                id = viewModel.id,
                templateId = viewModel.templateId,
                resourceId = viewModel.resourceId,
                titleId = viewModel.titleId,
                dow = viewModel.dow,
                startTimeStr = viewModel.startDate.ToString(),
                duration = (int)((viewModel.endDate - viewModel.startDate).Ticks)
            };
        }
        public EntityViewModel Convert(Entity entity)
        {
            var startDate = DateTime.Parse(entity.startTimeStr);
            return new EntityViewModel
            {
                id = entity.id,
                templateId = entity.templateId,
                resourceId = entity.resourceId,
                titleId = entity.titleId,
                dow = entity.dow,
                startDate = startDate,
                endDate = startDate.AddTicks(entity.duration)
            }
        }
    }
