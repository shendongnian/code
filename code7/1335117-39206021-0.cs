    public void Convert(bool toGuid, string parent, params string[] children)
        {
            if (toGuid)
            {
                AddColumn($"dbo.{parent}s", "Id2", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            }
            else
            {
                AddColumn($"dbo.{parent}s", "Id2", c => c.Int(nullable: false, identity: true));
            }
            foreach (var child in children)
            {
                DropForeignKey($"dbo.{child}s", $"{parent}_Id", $"dbo.{parent}s");
                DropIndex($"dbo.{child}s", new[] { $"{parent}_Id" });
                RenameColumn($"dbo.{child}s", $"{parent}_Id", $"old_{parent}_Id");
                if (toGuid)
                {
                    AddColumn($"dbo.{child}s", $"{parent}_Id", c => c.Guid());
                }
                else
                {
                    AddColumn($"dbo.{child}s", $"{parent}_Id", c => c.Int());
                }
                Sql($"update c set {parent}_Id=p.Id2 from {child}s c inner join {parent}s p on p.Id=c.old_{parent}_Id");
                DropColumn($"dbo.{child}s", $"old_{parent}_Id");
            }
            DropPrimaryKey($"dbo.{parent}s");
            DropColumn($"dbo.{parent}s", "Id");
            RenameColumn($"dbo.{parent}s", "Id2", "Id");
            AddPrimaryKey($"dbo.{parent}s", "Id");
            foreach (var child in children)
            {
                CreateIndex($"dbo.{child}s", $"{parent}_Id");
                AddForeignKey($"dbo.{child}s", $"{parent}_Id", $"dbo.{parent}s", "Id");
            }
        }
