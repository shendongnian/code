    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void GetIndexedValuesWhenDeserializingJSONIntoDynamicObject() {
            var s = @"
            {
                'RolePermissions': [
                    {
                        'RolePermissionId': '269',
                        'HasAccess': 'false'
                    },
                    {
                        'RolePermissionId': '270',
                        'HasAccess': 'false'
                    },
                    {
                        'RolePermissionId': '271',
                        'HasAccess': 'true'
                    },
                    {
                        'RolePermissionId': '272',
                        'HasAccess': 'false'
                    }
                ]
            }
            ";
            var ssObj = JsonConvert.DeserializeObject<dynamic>(s);
            var result = ssObj.RolePermissions[0].RolePermissionId;
            Assert.AreEqual("269", (string)result);
        }
    }
