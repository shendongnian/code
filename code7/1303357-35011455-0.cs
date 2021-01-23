        const string sql = "DeleteVersion @pVersiontId";
        using (IContext ctx = DI.Container.Resolve<IContext>()) {
            try {
                ctx.ExecuteCommand(sql, new SqlParameter("@pVersiontId", versionId));
            } catch (SqlException ex) {
                LoggerFactory.CreateLog().LogError(String.Format(Resources.CouldNotDeleteDeVersion, versionId), ex);
                throw new CannotDeleteVersionExcpetion(String.Format(Resources.CouldNotDeleteDeVersion, versionId), ex);
            }
        }
