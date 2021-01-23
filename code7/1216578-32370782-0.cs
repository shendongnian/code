    public interface IItemSetSpawnController {
        void TransitSpawned(GameMap.ItemSet set);
    }
    public class ItemSetSpawnController : IItemSetSpawnController {
        readonly LootableFactoryDelegate _lootableFactory;
        readonly IFiber _fiber;
        readonly ISessings settings;
        public ItemSetSpawnController(ISessings settings,
            [NotNull] LootableFactoryDelegate lootableFactory, IFiber fiber) {
            _lootableFactory = lootableFactory;
            _fiber = fiber;
            _settings = settings;
        }
        public void TransitSpawned([NotNull] GameMap.ItemSet set) {
            if (set == null) throw new ArgumentNullException(nameof(set));
            // If LootRespawnTime is a config value that doesn't change after startup, you
            // can more it back into the constructor of the controller.
            int defaultRespawnTime = _ettings.LootRespawnTime;
            // Fiber.Schedule for respawning
        }
    }
    class MapLooter {
        IItemSetSpawnController controller;
        public MapLooter(IItemSetSpawnController controller){
            this.controller = controller;
        }
        public void AddMapLootables() {
            foreach (var set in ItemSets) {
                if (set.Items.Count == 0) continue;
                this.controller.TransitSpawned(set);
            }
        }
    }
