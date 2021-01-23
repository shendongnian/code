    class DynamicTest : Test {
        private readonly Action _getData;
        public DynamicTest(Action getData) {
            _getData = getData;
        }
        public override void GetData() {
            _getData();
        }
